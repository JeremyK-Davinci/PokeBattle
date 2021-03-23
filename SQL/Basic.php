<?php 
    require ("Connector.php");
    session_start();

    function sanitize($data){
        $data = trim($data);
        $data = htmlspecialchars($data);
        $data = stripcslashes($data);
        return $data;
    }

    function setPageTitle($title, $contents){
        ob_end_clean();
        echo str_replace('<!--Title-->', $title, $contents);
    }

    function createRoomHTMLObject($roomId, $roomName, $roomPlayerNames){
        return 
            "<div class='col-12 text-center border border-light rounded mb-4 mt-2'>
                <h4 class='text-light pt-2 col-12'>" . $roomName. "</h4>
                <p class='text-light pt-2'>Players : " . $roomPlayerNames . "</p>
                <button type='button' class='btn btn-outline-light btnJoin mb-2' value=" . $roomId . ">Join</button>
            </div>";
    }

    function getPokemonFromUser($userId){
        $conn = openConnection();
        $query = $conn->prepare("SELECT Pokemon FROM users WHERE id=:id");
        $query->bindParam(":id", $id);
        $query->execute();
        $result = $query->fetchAll();
        return $result;
    }

    function getInfoFromUserId($id){
        $conn = openConnection();
        $query = $conn->prepare("SELECT * FROM users WHERE id=:id");
        $query->bindParam(":id", $id);
        $query->execute();
        $result = $query->fetchAll();
        return $result[0];
    }