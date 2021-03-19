<?php 
    require ("../Basic.php");
    session_start();

    $username = sanitize($_POST['registerName']);
    $mail = sanitize($_POST['registerMail']);
    $password = sanitize($_POST['registerPass']);
    $passwordConfirm = sanitize($_POST['registerPassConfirm']);
    
    if(empty(trim($username))){
        echo "Username cannot be empty";
        return;
    }
    if(empty(trim($mail))){
        echo "Mail cannot be empty";
        return;
    }
    if(md5($password) !== md5($passwordConfirm)){
        echo "Passwords don't match";
        return;
    }

    try{
        session_start();

        $conn = openConnection();
        $query = $conn->prepare("SELECT * FROM users WHERE mail=:em");
        $query->bindParam(":em", $mail);
        $query->execute();
        $result = $query->fetchAll();
        if($query->rowCount($result) > 0){
            echo "$mail - This email already exists";
            return;
        }
        else{
            $query = $conn->prepare("INSERT INTO users (username, password, mail) VALUES (:un, :pw, :em)");
            $query->bindParam(":un", $username);
            $query->bindParam(":pw", md5($password));
            $query->bindParam(":em", $mail);
            $query->execute();

            $query = $conn->prepare("SELECT * FROM users WHERE mail=:em");
            $query->bindParam(":em", $mail);
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
                echo "Failed logging in, please try manually";
                return;
            }
        }
    }
    catch(PDOException $e){
        echo "php error -> " . $e->getMessage();
        return;
    }