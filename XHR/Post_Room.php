<?php
    require ("../SQL/Basic.php");
    session_start();

    $roomId = sanitize($_POST['roomId']);
    $_SESSION['roomId'] = $roomId;
    session_write_close();
    echo "success";
