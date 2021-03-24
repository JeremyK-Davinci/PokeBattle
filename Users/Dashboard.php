<?php include ("../Includes/Header2.php");?>
<?php 
    require ("../Classes/Type.php");
    require ("../Classes/Attack.php");
    require ("../Classes/Pokemon.php");

    if(!isset($_SESSION['signedIn'])){
        header("location: ../Index.php");
    }
    $Pokemons = getPokemonFromUser($_SESSION['userId']);

    $baseImageLinkFront = "https://img.pokemondb.net/sprites/bank/normal/%s.png";
    $vals = json_encode($BasePokemon);
?>

<div class="d-flex flex-row flex-wrap">
    <div class="user-info col-lg-4 col-12">
        <form action="#" enctype="multipart/form-data" type="post" class="updateUserForm">
            <h1 class="text-lg-left text-center text-light user-info-title"><?= $_SESSION['username']?></h1>
            <div class="border border-bottom-0 border-left-0 border-right-0 border-light mb-3">
                <p class="border rounded bg-danger text-light text-center responseFail mt-3"></p>
                <p class="border rounded bg-success text-light text-center responseSuccess mt-3"></p>
                <div class="row-username d-flex flex-xxl-row flex-column mt-3 ml-xl-5">
                    <label for="username" class="text-light flex-column h3">Username : </label>
                    <input type="text" class="form-control col-8 offset-1 flex-column updateName" name="username" value=<?= $_SESSION['username']?>>
                </div>
                <div class="row-mail d-flex flex-xxl-row flex-column mt-3 ml-xl-5">
                    <label for="mail" class="text-light flex-column h3 pr-5">E-Mail : </label>
                    <input type="text" class="form-control col-8 offset-1 flex-column updateMail" name="mail" value=<?= $_SESSION['mail']?>>
                </div>
                <div class="row-password d-flex flex-xxl-row flex-column mt-3 ml-xl-5">
                    <label for="password" class="text-light flex-column h3 pr-2-o">Password : </label>
                    <input type="password" class="form-control col-8 offset-1 flex-column updatePass" name="password" value="########">
                </div>
                <input type="submit" class="btn btn-outline-light col-6 offset-3 rounded btnUpdateUser mt-5" name="Update" value="Update">
            </div>
        </form>
    </div>
    <div class="user-pokemon col-lg-8 col-12">
        <input class="JSTransfer" type="hidden" value=<?="'".$vals."'"?>>
        <h1 class="text-center text-light user-pokemon-title"><?= $_SESSION['username']?>'s Pokemon</h1>
        <div class="border border-bottom-0 border-left-0 border-right-0 border-light mb-3 pokeContainer d-flex flex-row flex-wrap">
            <button class="btn btn-outline-light col-lg-1 col-4 ml-lg-4 mr-lg-4 mt-3 pt-3 pb-4 btnPokemon"> <!--These buttons are just here for a layout reference-->
                <img class="img-fluid img-Pokemon" src="<?=sprintf($baseImageLinkFront, "oshawott")?>" alt="Oshawott">
                <p class="pokemonName">Oshawott</p>
            </button>
            <button class="btn btn-outline-light col-lg-1 col-4 ml-lg-4 mr-lg-4 mt-3 pt-3 pb-4 btnPokemon">
                <img class="img-fluid img-Pokemon" src="<?=sprintf($baseImageLinkFront, "oshawott")?>" alt="Oshawott">
                <p class="pokemonName">Oshawott</p>
            </button>
            <button class="btn btn-outline-light col-lg-1 col-4 ml-lg-4 mr-lg-4 mt-3 pt-3 pb-4 btnPokemon">
                <img class="img-fluid img-Pokemon" src="<?=sprintf($baseImageLinkFront, "oshawott")?>" alt="Oshawott">
                <p class="pokemonName">Oshawott</p>
            </button>
            <?php foreach($Pokemons as $Pokemon){?>
                <button class="btn btn-outline-light col-lg-1 col-4 ml-lg-4 mr-lg-4 mt-3 pt-3 pb-4 btnPokemon" type="button" value="<?= $Pokemon['name']?>">
                    <img class="img-fluid img-Pokemon" src="<?=sprintf($baseImageLinkFront, strtolower($Pokemon['name']))?>" alt="<?= $Pokemon['name']?>">
                    <p class="pokemonName">Oshawott</p>
                </button>
            <?php }?>
        </div>
        <button class="btnTest btn btn-outline-light">Add Pokemon</button>
    </div>
</div>

<script src="../JS/Dashboard.js"></script>
<?php include ("../Includes/Footer.php");?>

<?php
    setPageTitle("Dashboard", ob_get_contents());
    /**/
?>