<?php
    $table = "tbEmployee";
    $ED_Username = $_GET["user"];
    $ED_Password = $_GET["psw"];

    echo $ED_Username.$ED_Password;
   

    $LoggedInUserInfo = sqlSelectStatement($table, $ED_Username, $ED_Password);

   
    if(Isset($LoggedInUserInfo)){

        if($LoggedInUserInfo["UT_ID"] == 2){

            header('Location: html2.0FoodOrder.html?ID='.$LoggedInUserInfo["ED_ID"]);

        }elseif($LoggedInUserInfo["UT_ID"] == 3){
            header('Location: html3.0ChefFoodStatus.html?ID='.$LoggedInUserInfo["ED_ID"]);
        }
        elseif($LoggedInUserInfo["UT_ID"] == 4){
            header('Location: html4.0Accountant.html?ID='.$LoggedInUserInfo["ED_ID"]);
        }
        elseif($LoggedInUserInfo["UT_ID"] == 1){
            header('Location: html1.0Reservation.html?ID='.$LoggedInUserInfo["ED_ID"]);
        }
       
       

     }
    //  else{
    //     header('Location: htmlLogin.html?ID=noUser');

    // }
    
    function checkConn()
    {
        $connObj = array();
        $serverName = "DESKTOP-MIJFBAE\SQLEXPRESS";
        $connectionInfo = array("Database"=>"KingCrab","UID"=>"sa","PWD"=>"password");
        $conn = sqlsrv_connect($serverName, $connectionInfo);

        if($conn === false)
        {
            $connObj[-1] = sqlsrv_errors()[0]['message']; 
        }
        else //if true
        {
            $connObj[0] = $conn;
        }
        return $connObj;
    }

    function sqlSelectStatement($tableName, $ED_Username, $ED_Password)
    {
        // get all the column headers
        $tbHead = array();
        $myObj = array();

        // these just concatinate together
        $colHead = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'";
        $colHead .= $tableName . "'";

        $query = "SELECT * FROM [" . $tableName;
        $query .= "]"."WHERE "."ED_Username ='".$ED_Username."' AND ED_Password ='".$ED_Password."'";
        echo $query; 

        $conStat = checkConn();

        if(isset($conStat[0]))
        {
            $connStr = $conStat[0];
            $stmt = sqlsrv_query($connStr, $colHead);

            if($stmt === false)
            {
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
            
                if($stmt === false)
                {
                    $myJSON = json_encode($myObj);
                    echo $myJSON;
                    $myObj["Error2"] = sqlsrv_errors()[0]['message'];
                }

                else
                {
                    while($rows = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC))
                    {
                        $temp = array();
        
                        for($x = 0; $x < count($tbHead); $x++)
                        {
                            $temp[$tbHead[$x]] = $rows[$tbHead[$x]];
                        }
                         // Tbdhead = columnname
                        // rows = content 
        
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
        foreach($myObj as $value){
            $LoggedInUserInfo =[
                'ED_ID' =>  $value["ED_ID"],
                'UT_ID' => $value["UT_ID"]
            ];
        }
        return  $LoggedInUserInfo;

       

        
    //    echo $myJSON;
    }

    
?>