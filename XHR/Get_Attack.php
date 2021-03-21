<?php
    require ("../SQL/Basic.php");
    session_start();

    $output = "";
    $roomId = $_SESSION['roomId'];
    $userId = $_SESSION['userId'];

    try{
        $conn = openConnection();
        $query = $conn->prepare("SELECT * FROM attacks WHERE roomId=:room");
        $query->bindParam(":room", $roomId);
        $query->execute();
        $result = $query->fetchAll();
        if($query->rowCount($result) > 0){
            $sender = $result[0]['senderId'];
            if($sender == $userId) return;
            else{
                $output = "success" . $result[0]['attack'];
                $query = $conn->prepare("DELETE FROM attacks WHERE roomId=:room");
                $query->bindParam(":room", $roomId);
                $query->execute();
                echo $output;
                return;
            }
        }
    }
    catch(PDOException $e){
        echo "php error -> " . $e->getMessage();
        return;
    }