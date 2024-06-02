<?php

include('db.php');

try {
    // Define and perform the SQL SELECT query
    $sql = "SELECT * FROM `students`";
    $result = $conn->query($sql);

    // Check if any data is returned
    if ($result->rowCount() > 0) {
        $data = [];
        // Parse returned data and store them in $data array
        while ($row = $result->fetch(PDO::FETCH_ASSOC)) {
            $data[] = $row;
        }
        echo json_encode($data);
    } else {
        // No data found, send a message or handle it differently
        echo json_encode("");
    }

    $conn = null; // Disconnect
} catch (PDOException $e) {
    echo $e->getMessage();
}
