<?php
    
    $userID = $_GET["UserID"];

    sqlSelectStatement($userID);
    header('Location: CustomerInfo.html?status=EmailVerified');
    //checkConn();


    function checkConn()
    {
        $connObj = array();
        $serverName = "DESKTOP-MIJFBAE\SQLEXPRESS";
        $connectionInfo = array("Database"=>"BankDBO","UID"=>"sa","PWD"=>"password");
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

    function sqlSelectStatement($userID)
    {
       

        $query = "exec UspUpdatEmailVerification " . $userID;
       


        $conStat = checkConn();
        if(isset($conStat[0]))
        {
            $connStr = $conStat[0];
            $stmt = sqlsrv_query($connStr, $query);
            if($stmt === false)
            {
                //echo "Error executing script. </br>";
                //die (print_r(sqlsrv_errors()[0]['message'], true));
                $myObj = "Conflict detected somewhere!"; // feel free error messages
            }
            else
            {
                $myObj = "Insert Successful!";
            }
        }
                
        //$myJSON = json_encode($myObj);
        

        echo $myObj;
    }

    
?>