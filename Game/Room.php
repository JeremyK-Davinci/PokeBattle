<?php include ("../Includes/Header2.php");?>
<?php
    require ("../Classes/Type.php");
    require ("../Classes/Attack.php");
    require ("../Classes/Pokemon.php");
    
    if(!isset($_SESSION['signedIn'])){
        header("location:../Index.php");
    }

    $baseImageLinkFront = "https://img.pokemondb.net/sprites/black-white/anim/normal/%s.gif";
    $baseImageLinkBack = "https://img.pokemondb.net/sprites/black-white/anim/back-normal/%s.gif";

    $myPokemon = new Pokemon('Pikachu', $Types[3], 35, 5, [new Attack('Quik Attack', 40, $Types[4], 4), new Attack('Tail Whip', 0, $Types[4], 1), new Attack('Thunder Wave', 0, $Types[3], 1)]);
    $enemyPokemon = new Pokemon('Squirtle', $Types[1], 44, 5, [new Attack('Tackle', 40, $Types[4], 1), new Attack('Tail Whip', 0, $Types[4], 1), new Attack('Water Gun', 40, $Types[1], 1)]);
?>

<div id="game-container" class="col-12">
    <div id="game-display-container" class="col-10 col-lg-6 offset-1 offset-lg-3 d-block">
        <div id="pokemon-row-enemy" class="w-100 d-flex justify-content-end">
            <div id="pokemon-info-display" class="text-left bg-light h-25 rounded-left">
                <div id="pokemon-text-info" class="col-12 d-inline-flex">
                    <p class="pl-2"><?=$enemyPokemon->name?>
                        <p class="pl-3 pr-2 font-weight-bold">Lvl. <?=$enemyPokemon->level?></p>
                    </p>
                </div>
                <div id="pokemon-health-info" class="col-12">
                    <progress id="pokemon-health-enemy" value="<?=$enemyPokemon->hitPoints?>" max="<?=$enemyPokemon->maxHitPoints?>"></progress>
                </div>
            </div>
            <div id="pokemon-display">
                <img src="<?=sprintf($baseImageLinkFront, strtolower($enemyPokemon->name))?>" alt="Squirtle" width="150" height="150">
            </div>
        </div>
        <div id="pokemon-row-me" class="w-100 d-flex justify-content-start">
            <div id="pokemon-display">
                <img src="<?=sprintf($baseImageLinkBack, strtolower($myPokemon->name))?>" alt="Pikachu" width="150" height="150">
            </div>
            <div id="pokemon-info-display" class="text-left bg-light h-25 rounded-right">
                <div id="pokemon-text-info" class="col-12 d-inline-flex">
                    <p class="pl-2"><?=$myPokemon->name?>
                        <p class="pl-3 pr-2 font-weight-bold">Lvl. <?=$myPokemon->level?></p>
                    </p>
                </div>
                <div id="pokemon-health-info" class="col-12">
                    <progress id="pokemon-health-me" value="<?=$myPokemon->hitPoints?>" max="<?=$myPokemon->maxHitPoints?>"></progress>
                    <p id="pokemon-health-text" class="pl-1">Health: <?=$myPokemon->hitPoints?>/<?=$myPokemon->maxHitPoints?></p>
                </div>
            </div>
        </div>
    </div>
    <div id="game-button-container" class="col-8 col-lg-4 offset-2 offset-lg-4 d-block pl-3 pl-lg-5 bg-light rounded border border-dark fixed-bottom pb-5">
        <h3 class="text-center text-danger pr-5 responseFail"></h3>
        <h3 class="text-center text-success pr-5 responseSuccess"></h3>
        <?php foreach($myPokemon->attacks as $attack){?>
            <button type="button" class="btn <?=$attack->type->name?> btnAttack col-5 ml-3 ml-md-4 mt-3" value='<?php print_r($attack->__toString())?>'><?=$attack->name?></button>
        <?php }?>
    </div>
</div>

<form action="#" enctype="multipart/form-data" class="gameForm">
    <input type="hidden" name="attack" class="attack" value=''>
    <input type="hidden" name="enemyPokemon" class="enemyPokemon" value='<?=$enemyPokemon?>'>
    <input type="hidden" name="myPokemon" class="myPokemon" value='<?=$myPokemon?>'>
</form>

<script src="../JS/Room.js"></script>
<?php include ("../Includes/Footer.php");?>

<?php
    setPageTitle("Room " . $_SESSION['roomId'], ob_get_contents());
?>