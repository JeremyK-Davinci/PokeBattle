<?php
    require ("../Basic.php");
    session_start();

    $newPass = sanitize($_POST['newPassword']);
    $confirmNewPass = sanitize($_POST['confirmNewPassword']);

    if(empty(trim($newPass)) || empty(trim($confirmNewPass)) || md5($newPass) !== md5($confirmNewPass)){
        echo "Passwords don't match";
        return;
    }

    try{
        $conn = openConnection();
        $query = $conn->prepare("UPDATE users SET password=:pw WHERE id=:id");
        $query->bindParam(":pw", md5($newPass));
        $query->bindParam(":id", $_SESSION['userId']);
        $query->execute();
        $conn = null;
        echo "success";
        return;
    }
    catch(PDOException $e){
        echo "php error -> " . $e->getMessage();
        return;
    }