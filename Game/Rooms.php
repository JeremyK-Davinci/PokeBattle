<?php include ("../Includes/Header2.php");?>
<?php
    if(!isset($_SESSION['signedIn'])){
        header("location:../Index.php");
    }
?>
<div class="errorDisplay fixed-top mt-5 w-100 text-white bg-danger text-center"></div>
<div class="headContainer col-12">
    <h1 class="text-center text-light title"></h1>
</div>
<div class="container"></div>

<form action="#" enctype="multipart/form-data" method="post" class="roomForm">
    <input type="hidden" name="roomId" id="roomIdHolder" value="">
</form>
<script src="../JS/Rooms.js"></script>
<?php include ("../Includes/Footer.php");?>

<?php
    setPageTitle("Rooms", ob_get_contents());
?>