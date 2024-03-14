<?php
     if(Isset($_GET["submit"])){
        $customerFirstName = $_GET["customerFirstName"];
        $customerLastName = $_GET["customerLastName"];
        $emailAdd = $_GET["emailAdd"];
        $contactNumber = $_GET["contactNumber"];
        $numberofcustomer = $_GET["numberofcustomer"];
        $dateTime = $_GET["dateTime"];
        $TableID = $_GET["TableID"];
       // $UserID = $_GET["UserID"];
     
       $fDate = str_replace("T",' ', $dateTime);
        sqlInsertUser($customerFirstName , $customerLastName , $emailAdd , $contactNumber , $numberofcustomer ,$fDate,$TableID);
        // echo '<script>alert("Email send!");</script>';
        header('Location: html1.0Reservation.html');
        //header('Location: html1.0Reservation.html?');
        echo "isset working";
        //$formatteddate = strftime('%Y-%m-%dT%H:%M:%S', $dateTime);
        //echo $customerFirstName.' '.$customerLastName.' '.$emailAdd.' '.$contactNumber.' '.$numberofcustomer.' '.$fDate.' '.$TableID;
        //echo $customerFirstName.$customerLastName. $emailAdd.$contactNumber.$numberofcustomer.$dateTime.$TableID;
       

    }else{
        header('Location: LoginForm.html?status=notRegistered');
        exit();
        // echo "isset not working";

    }
   
 
    


    function checkConn()
    {
        $connObj = array();

        $serverName = "DESKTOP-MIJFBAE\\SQLEXPRESS";
        $connectionInfo = array("Database"=>"KingCrab","UID"=>"sa","PWD"=>"password");
    
        $conn = sqlsrv_connect($serverName, $connectionInfo);
        if($conn === false)
        {
            $connObj[-1] = sqlsrv_errors()[0]['message']; // this is the DB login error message, feel free to change JUST the message
            //echo sqlsrv_errors()[0]['message'];
            //die (print_r(sqlsrv_errors(), true));
        }
        else
        {
            $connObj[0] = $conn;
        }

        return $connObj;
    }

    // only does select * preferably used with vews :)
    // no where statement
    // specific statements with specific where statements are often much better with their own functions
  
    function sqlInsertUser($customerFirstName , $customerLastName , $emailAdd , $contactNumber , $numberofcustomer ,$dateTime, $TableID)
    {
        $query =  "exec uspAddReservationDetail  '" . $customerFirstName . "', '" . $customerLastName . "', '" . $emailAdd ."', '" . $contactNumber ."', '" . $numberofcustomer ."'
        , '" . $dateTime."', '" . $TableID."'";
        // echo $query;

        // "exec UspInsertUser  '" . $emailAddress . "', '" . $firstName . "', '" . $lastName ."', '" . $password ."', '" . $picturePath ."'
        // , '" . $gender. "', '" . $IDVerified . "', '" . $emailVerified . "', '" . $oTPcode . "', '" . $latestAccountID ."'";

        
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
        //7.4.9 
        

        echo $myObj;
    }

?>
