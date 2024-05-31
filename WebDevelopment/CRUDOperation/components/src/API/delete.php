<?php
include("db.php");

$ID = isset($_POST['ID']) ? trim($_POST['ID']) : ''; // Sanitize and handle missing values

// Prepared statement for secure data insertion
$sql = "DELETE fROM students WHERE student_ID = ?";
$stmt = $conn->prepare($sql);

// Bind parameters to prevent SQL injection
$stmt->bindParam(1, $ID);

try {
    $stmt->execute();
    echo "Deleted successfully";
} catch (PDOException $e) {
    echo "Error: " . $e->getMessage();
}

$conn = null; // Close connection (optional)
