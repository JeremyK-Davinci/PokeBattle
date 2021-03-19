<?php include ("../Includes/Header2.php");?>
<?php 
    if(!isset($_SESSION['signedIn'])){
        header("location: ../Index.php");
    }
?>

<?php include ("../Includes/Footer.php");?>

<?php
    setPageTitle("Dashboard", ob_get_contents());
?>