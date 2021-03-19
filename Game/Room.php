<?php include ("../Includes/Header2.php");?>
<?php
    require ("../Classes/Type.php");
    require ("../Classes/Attack.php");
    require ("../Classes/Pokemon.php");

    if(!isset($_SESSION['signedIn'])){
        header("location:../Index.php");
    }

    $myPokemon = new Pokemon('Squirtle', $Types[1], 44, 5, [new Attack('Tackle', 40, $Types[4]), new Attack('Tail Whip', 0, $Types[4]), new Attack('Water Gun', 40, $Types[2])]);
    $enemyPokemon = new Pokemon('Pidgey', $Types[4], 40, 7, [new Attack('Tackle', 40, $Types[4]), new Attack('Sand Attack', 0, $Types[8]), new Attack('Gust', 40, $Types[6])]);
?>

<div id="game-container" class="col-12">
    <div id="game-button-container" class="col-8 offset-2 d-block pl-5">
        <?php foreach($myPokemon->attacks as $attack){?>
            <button type="button" class="btn btn-outline-light <?=$attack->type->name?> btnAttack col-5 ml-5 mt-3" value=<?=$attack->__toString()?>><?=$attack->name?></button>
        <?php }?>
    </div>
</div>

<form action="#" enctype="multipart/form-data" class="gameForm">
    <input type="hidden" name="attack" class="attack" value="">
</form>

<script src="../JS/Room.js"></script>
<?php include ("../Includes/Footer.php");?>

<?php
    setPageTitle("Room " . $_SESSION['roomId'], ob_get_contents());
?>