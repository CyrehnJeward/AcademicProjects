<?php
$table = $_GET["Table"];
$updateID =$_GET["updateID"];
//$removeID =$_GET["removeID"];
// $start = $_GET["rStart"];
// $userID =$_GET["userID"];
if(Isset($updateID)){
    UpdateStatus($updateID);
    selectStmt($table);
    //echo 'update----iset';
}
// else if(Isset($removeID)){
//     removeStatus($removeID);
//     selectStmt($table);
//     //echo 'removeiset';
// }
else{
    selectStmt($table);
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
    function selectStmt($tableName)
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
        $query .= "]" ;
    
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
                
        $myJSON = json_encode($myObj);
        echo $myJSON;
    }
    
    function UpdateStatus($TableID)
    {
        $query = "exec uspRemoveReservationStatus " . $TableID;
        
    
        $conStat = checkConn();
        if(isset($conStat[0]))
        {
            $connStr = $conStat[0];
            $stmt = sqlsrv_query($connStr, $query);
           
        }
    }

    // function removeStatus($TableID)
    // {
    //     $query = "exec uspRemoveReservationStatus " . $TableID;
        
    
    //     $conStat = checkConn();
    //     if(isset($conStat[0]))
    //     {
    //         $connStr = $conStat[0];
    //         $stmt = sqlsrv_query($connStr, $query);
           
    //     }
    // }
    
?>