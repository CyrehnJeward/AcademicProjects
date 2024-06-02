<?php
    $table = $_GET["Table"];
    $TableID =$_GET["TableID"];

  
    if(Isset($TableID)){
        UpdateStatus($TableID);
    }
    function checkConn()
    {
        $connObj = array();

        $serverName = "DESKTOP-MIJFBAE\SQLEXPRESS";
        $connectionInfo = array("Database"=>"KingCrab","UID"=>"sa","PWD"=>"password");
    
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


    function UpdateStatus($TableID)
    {
        $query = "exec uspUpdateReservationStatus " . $TableID;
        
    
        $conStat = checkConn();
        if(isset($conStat[0]))
        {
            $connStr = $conStat[0];
            $stmt = sqlsrv_query($connStr, $query);
           
        }
    }
    
?> 