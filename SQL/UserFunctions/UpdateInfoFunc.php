<?php
    require ("../Basic.php");
    session_start();

    $username = sanitize($_POST['username']);
    $mail = sanitize($_POST['mail']);

    if(empty(trim($username))){
        echo "Username cannot be empty";
        return;
    }
    if(empty(trim($mail))){
        echo "Mail cannot be empty";
        return;
    }

    try{
        $conn = openConnection();

        $query = $conn->prepare("SELECT * FROM users WHERE mail=:em");
        $query->bindParam(":em", $mail);
        $query->execute();
        $result = $query->fetchAll();
        if($query->rowCount($result) > 0){
            if($result[0]['id'] != $_SESSION['userId']){
                echo "Cannot use  $mail as mail. This mail already exists";
                return;
            }
        }

        $query = $conn->prepare("UPDATE users SET username=:un, mail=:em WHERE id=:id");
        $query->bindParam(":un", $username);
        $query->bindParam(":em", $mail);
        $query->bindParam(":id", $_SESSION['userId']);
        $query->execute();

        $query = $conn->prepare("SELECT * FROM users WHERE id=:id");
        $query->bindParam(":id", $_SESSION['userId']);
        $query->execute();
        $result = $query->fetchAll();
        if($query->rowCount($result) > 0){
            $_SESSION['username'] = $result[0]['username'];
            $_SESSION['mail'] = $result[0]['mail'];
            $conn = null;
            echo "success";
            return;
        }
        else{
            echo "Failed retrieving info from user after update, manual refresh required.";
            return;
        }
    }
    catch(PDOException $e){
        echo "php error -> " . $e->getMessage();
        return;
    }
?>