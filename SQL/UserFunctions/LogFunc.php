<?php 
    require ("../Basic.php");
    session_start();

    $username = sanitize($_POST['loginName']);
    $password = sanitize($_POST['loginPass']);

    if(empty(trim($username))){
        echo "Username cannot be empty";
        return;
    }
    if(empty(trim($password))){
        echo "Password cannot be empty";
        return;
    }

    try{
        session_start();

        $conn = openConnection();
        $query = $conn->prepare("SELECT * FROM users WHERE username=:un and password=:pw");
        $query->bindParam(":un", $username);
        $query->bindParam(":pw", md5($password));
        $query->execute();
        $result = $query->fetchAll();
        if($query->rowCount($result) > 0){
            session_regenerate_id();
            $_SESSION['signedIn'] = true;
            $_SESSION['userId'] = $result[0]['id'];
            $_SESSION['username'] = $result[0]['username'];
            session_write_close();
            $conn = null;
            echo "success";
            return;
        }
        else{
            echo "Failed logging in, check credentials and retry";
            return;
        }
    }
    catch(PDOException $e){
        echo "php error -> " . $e->getMessage();
        return;
    }