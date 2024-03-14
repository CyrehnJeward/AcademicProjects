<?php
    // $_FILES is a predefined variable that is automatically declared and initialized when the HTML has the HTTP POST method.
    // this can be seen in FTP-Front.html line 6.

    $target_dir = "C:\wamp64\www\Midterm\MidtermProject\Pictures"; // --> specifies the directory where the file is going to be placed
    $target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]); // --> specifies location of where the file will be uploaded to
    $uploadedFile = basename($_FILES["fileToUpload"]["name"]);
    $uploadOk = 1; // --> indicator if file upload is successful of not
    $imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION)); // --> holds the file extension of the file (in lower case)

    // Check if image file is a actual image or fake image

    // this lump of code is actually only used to check for images
    // the goal of this section is actually to check if the file has a size greater than 0 
    // and to see that its an image media file
    // more info here : https://www.geeksforgeeks.org/php-getimagesize-function/
    // if you want to just upload other files, I suggest changing getimagesize() filesize()
    if(isset($_POST["submit"])) // checks if something is submitted or not
    {
        $check = getimagesize($_FILES["fileToUpload"]["tmp_name"]); // checks image properties
        if($check !== false) 
        {
            echo "File is an image - " . $check["mime"] . ".";
            $uploadOk = 1;
        } 
        else 
        {
            echo "File is not an image.";
            header('Location: LoginForm.html?status=notImage');
            $uploadOk = 0;
        }
    }

    // Check if file already exists
    // if the files DONT have to be unique you can ommit this.
    if (file_exists($target_file)) 
    {
        echo "Sorry, file already exists.";
        header('Location: LoginForm.html?status=alreadyExist');
        $uploadOk = 0;
    }

    // Check file size
    // first block of code checks if the file is actually a file by having a size
    // this block of code will LIMIT the size in bytes.
    if ($_FILES["fileToUpload"]["size"] > 500000) 
    {
        echo "Sorry, your file is too large.";
        header('Location: LoginForm.html?status=TooLarge');
        $uploadOk = 0;
    }

    // Allow certain file formats
    // this filters certain image file formats
    if($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg"
    && $imageFileType != "gif" ) 
    {
        echo "Sorry, only JPG, JPEG, PNG & GIF files are allowed.";
        $uploadOk = 0;
        header('Location: LoginForm.html?status=fileType');
    }

    // Check if $uploadOk is set to 0 by an error
    if ($uploadOk == 0) // this checks if the upload is successful based on the status messages above
    {
        echo "Sorry, your file was not uploaded.";
        // if everything is ok, try to upload file
        header('Location: LoginForm.html?status=notUploaded');
    }
    else 
    {
        // this attempts to make a copy of the file you want to upload
        // by copying it to the directory declared above

        // at this point if the file upload is successful, you will may want to add a transfer to ANOTHER 
        // script page, like an HTML or another PHP.
        if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file)) 
        {
            $filename = htmlspecialchars( basename( $_FILES["fileToUpload"]["name"]));
            echo "The file ". htmlspecialchars( basename( $_FILES["fileToUpload"]["name"])). " has been uploaded.";
            // put redirect here
            // sample https://www.php.net/manual/en/function.header.php
            header('Location: RegisterForm.html?image='."Pictures".$uploadedFile);
        } 
        else 
        {
            echo "Sorry, there was an error uploading your file.";
            header('Location: LoginForm.html?status=notUploaded');

        }
    }
?>
