<?php
    require ("../SQL/Basic.php");
    session_start();

    $attack = $_POST['attack'];

    try{
        $conn = openConnection();

    }
    catch(PDOException $e){
        echo "php error -> " . $e->getMessage();
        return;
    }