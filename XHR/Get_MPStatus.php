<?php
    require ("../SQL/Basic.php");
    session_start();

    $roomId = $_SESSION['roomId'];
    try{
        $conn = openConnection();
        $query = $conn->prepare("SELECT * FROM rooms WHERE id=:id");
        $query->bindParam(":id", $roomId);
        $query->exceute();
        $result = $query->fetchAll();
        if($query->rowCount($result) > 0){
            $status = $result[0]['status'];
            $players = explode(' ', $result[0]['playerIds']);
            if($status == "Active" && count($players) > 1){
                echo "Multiplayer";
                return;
            }
            else{
                echo "SinglePlayer";
                return;
            }
        }
    }
    catch(PDOException $e){
        echo "php error -> " . $e->getMessage();
        return;
    }