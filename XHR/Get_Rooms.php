<?php
    require ("../SQL/Basic.php");
    session_start();
    $output = "";

    try{
        $conn = openConnection();
        $query = $conn->prepare("SELECT * FROM rooms WHERE NOT status='Active'");
        $query->execute();
        $result = $query->fetchAll();
        if($query->rowCount($result) > 0){
            foreach($result as $row){
                $output .= createRoomHTMLObject($row['id'], $row['name'], $row['playerNames']);
            }
            echo $output;
        }
        $conn = null;
        return;
    }
    catch(PDOException $e){
        echo "php error -> " . $e->getMessage();
        return;
    }