<?php
$table = $_GET["Table"];
// $start = $_GET["rStart"];
$userID =$_GET["userID"];

$oTPcode = UspUpdateOTPCode($userID);
$email = selectStmt1($table,$userID);
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;
use PHPMailer\PHPMailer\Exception;

//Load Composer's autoloader
require 'vendor/autoload.php';

//Create an instance; passing `true` enables exceptions
$mail = new PHPMailer(true);
// $emailAddress = $_GET["emailAddress"];

$message = "This is your OTP code ".$oTPcode;

try {
    //Server settings
    // $mail->SMTPDebug = SMTP::DEBUG_SERVER;                      //Enable verbose debug output
    $mail->isSMTP();                                            //Send using SMTP
    $mail->Host       = 'smtp.gmail.com';                     //Set the SMTP server to send through
    $mail->SMTPAuth   = true;                                   //Enable SMTP authentication
    $mail->Username   = 'MabericKokoys@gmail.com';                     //SMTP username
    $mail->Password   = 'maberickokoys123';                               //SMTP password
    $mail->SMTPSecure = PHPMailer::ENCRYPTION_SMTPS;            //Enable implicit TLS encryption
    $mail->Port       = 465;                                    //TCP port to connect to; use 587 if you have set `SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS`

    //Recipients
    $mail->setFrom('MabericKokoys@gmail.com', 'Mailer');
    $mail->addAddress($email);     //Add a recipient
    // $mail->addAddress('ellen@example.com');               //Name is optional
    // $mail->addReplyTo('info@example.com', 'Information');
    // $mail->addCC('cc@example.com');
    // $mail->addBCC('bcc@example.com');

    //Attachments
    // $mail->addAttachment('/var/tmp/file.tar.gz');         //Add attachments
    // $mail->addAttachment('/tmp/image.jpg', 'new.jpg');    //Optional name

    //Content
    $mail->isHTML(true);                                  //Set email format to HTML
    $mail->Subject = 'National Bank Email Verification';
    $mail->Body    = $message;
    $mail->AltBody = 'This is the body in plain text for non-HTML mail clients';

    $mail->send();
    // echo 'Message has been sent';
    // header('Location: CustomerInfo.html?status=EmailSent');
} catch (Exception $e) {
    // echo "Message could not be sent. Mailer Error: {$mail->ErrorInfo}";
    // header('Location: CustomerInfo.html?status=EmailNotSent');
}




    function checkConn()
    {
        $connObj = array();

        $serverName = "DESKTOP-6FT17GC\SQLEXPRESS";
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
  

    function generateNumericOTP($n) {
      
        // Take a generator string which consist of
        // all numeric digits
        $generator = "1357902468";
      
        // Iterate for n-times and pick a single character
        // from generator and append it to $result
          
        // Login for generating a random character from generator
        //     ---generate a random number
        //     ---take modulus of same with length of generator (say i)
        //     ---append the character at place (i) from generator to result
      
        $result = "";
      
        for ($i = 1; $i <= $n; $i++) {
            $result .= substr($generator, (rand()%(strlen($generator))), 1);
        }
      
        // Return result
        return $result;
    }

    function UspUpdateOTPCode($userID)
    {

        $oTPcode = generateNumericOTP(5);
        $query = "exec UspUpdateOTPCode '" . $userID . "', '" . $oTPcode . "'";
        //echo $query;

        
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
        return $oTPcode;
        

        // echo $myObj;
    }
    function selectStmt1($tableName,$userID)
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
        $query .= "] ". "WHERE userID = '" .$userID."'";
        // echo $query;
       

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

        foreach($myObj as $value){
            $email =($value["emailAddress"]);
        }
        

        echo $myJSON;
        return  $email;

       
    }
?>