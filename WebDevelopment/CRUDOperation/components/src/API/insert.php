<?php
include("db.php");

$fname = isset($_POST['fname']) ? trim($_POST['fname']) : ''; // Sanitize and handle missing values
$lname = isset($_POST['lname']) ? trim($_POST['lname']) : '';
$mn = isset($_POST['mn']) ? trim($_POST['mn']) : '';
$email = isset($_POST['email']) ? trim($_POST['email']) : '';

// Sanitize password (consider hashing for security)
$pw = isset($_POST['pw']) ? password_hash(trim($_POST['pw']), PASSWORD_DEFAULT) : '';

$ut = isset($_POST['ut']) ? trim($_POST['ut']) : '';

// Prepared statement for secure data insertion
$sql = "INSERT INTO students (FirstName, LastName, MobileNumber, Email, Password, UserType) VALUES (?, ?, ?, ?, ?, ?)";
$stmt = $conn->prepare($sql);

// Bind parameters to prevent SQL injection
$stmt->bindParam(1, $fname);
$stmt->bindParam(2, $lname);
$stmt->bindParam(3, $mn);
$stmt->bindParam(4, $email);
$stmt->bindParam(5, $pw);
$stmt->bindParam(6, $ut);

try {
    $stmt->execute();
    echo "New record created successfully";
} catch (PDOException $e) {
    echo "Error: " . $e->getMessage();
}

$conn = null; // Close connection (optional)
