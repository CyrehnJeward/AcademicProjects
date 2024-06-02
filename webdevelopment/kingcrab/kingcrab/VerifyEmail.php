<?php
    $emailAddress = $_GET["emailAddress"];
    // $start = $_GET["rStart"];
    $userID =$_GET["userID"];

    $tableName = "userTable";

    $myObj = selectStmt($tableName,$userID,$emailAddress);
    echo '<pre>'; print_r($myObj); echo '</pre>';
    if($myObj != null){
        if($myObj[$userID]["emailVerified"] == 0 && $myObj[$userID]["emailAddress"]  == $emailAddress ){

            header('Location: SMTP.php?emailAddress='.$myObj[$userID]["emailAddress"]."&userID=". $userID);
        }else{
            header('Location: CustomerInfo.html?status=WrongEmail');
    
        }
    }else{
        header('Location: CustomerInfo.html?status=WrongEmail');
    }

    // print_r($myObj[$userID]["emailAddress"]);

   
   


    function checkConn()
    {
        $connObj = array();

        $serverName = "DESKTOP-MIJFBAE\SQLEXPRESS";
        $connectionInfo = array("Database"=>"BankDBO","UID"=>"sa","PWD"=>"password");
    
        $conn = sqlsrv_connect($serverName, $connectionInfo);
        if($conn === false)
        {
            $connObj[-1] = sqlsrv_errors()[0]['message']; 
            // this is the DB login error message, feel free to change JUST the message
            //echo sqlsrv_errors()[0]['message'];
            //die (print_r(sqlsrv_errors(), true));
        }
        else
        {
            $connObj[0] = $conn;
        }

        return $connObj;
    }

    function selectStmt($tableName,$userID,$emailAddress)
    {
        // get all the column headers
        $tbHead = array();
        $myObj = array();
        $limit = 5;

        // these just concatinate together
        $colHead = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'";
        $colHead .= $tableName . "'";
        //echo $colHead;

        $query = "SELECT * FROM [" . $tableName;
        $query .= "]"."WHERE "."userID ='".$userID."' AND emailAddress ='".$emailAddress."'";
       

        $conStat = checkConn();
        if(isset($conStat[0]))
        {
            $connStr = $conStat[0];
            $stmt = sqlsrv_query($connStr, $colHead);
            if($stmt === false)
            {
                //echo "Error executing script. </br>";
                //die (print_r(sqlsrv_errors()[0]['message'], true));
                $myObj["Error1"] = sqlsrv_errors()[0]['message']; // feel free error messages
            }
            else
            {
                while($rows = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC))
                {
                    //echo $rows['COLUMN_NAME'];
                    array_push($tbHead, $rows['COLUMN_NAME']); // this is fixed for this logic
                }

                // now to get the true query results
                $stmt = sqlsrv_query($connStr, $query);
                //echo $query;
                
                //echo "im here";
                if($stmt === false)
                {
                    $myObj["Error2"] = sqlsrv_errors()[0]['message'];
                    //echo "Error executing script. </br>";
                    //die (print_r(sqlsrv_errors()[0]['message'], true));
                }
                else
                {
                    while($rows = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC))
                    {
                        $temp = array();
        
                        for($x = 1; $x < count($tbHead); $x++)
                        {
                            $temp[$tbHead[$x]] = $rows[$tbHead[$x]];
                        }
        
                        $myObj[$rows[$tbHead[0]]] = $temp;
                    }

                }
            }
        }
        else
        {
            $myObj["Error0"] = $conStat[-1];
        }
                
        // $myJSON = json_encode($myObj);

        // echo $myJSON;
        return $myObj;
    }

   
   
    
?> 