<?php
    require ("../SQL/Basic.php");
    session_start();

    $attack = json_encode(json_decode($_POST['attack']), JSON_PRETTY_PRINT);
    $senderId = $_SESSION['userId'];
    $roomId = $_SESSION['roomId'];

    try{
        $conn = openConnection();

        $query = $conn->prepare("SELECT * FROM attacks WHERE roomId=:room");
        $query->bindParam(":room", $roomId);
        $query->execute();
        $result = $query->fetchAll();
        if($query->rowCount($result) > 0){
            echo "Can't attack yet";
            return;
        }

        $query = $conn->prepare("INSERT INTO attacks (roomId, senderId, attack) VALUES (:room, :sender, :attack)");
        $query->bindParam(":room", $roomId);
        $query->bindParam(":sender", $senderId);
        $query->bindParam(":attack", $attack);
        $query->execute();
        $conn = null;
        echo "success";
        return;
    }
    catch(PDOException $e){
        echo "php error -> " . $e->getMessage();
        return;
    }