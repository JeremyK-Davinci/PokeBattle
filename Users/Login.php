<?php include ("../Includes/Header2.php");?>
<?php 
    if(isset($_SESSION['signedIn'])){
        header("location: ../Index.php");
    }
?>
<div class="errorDisplay fixed-top mt-5 w-100 text-white bg-danger text-center"></div>
<div class="form-container border border-dark rounded col-8 col-md-6 col-lg-2 offset-2 offset-md-3 offset-lg-5">
    <h1 class="text-white text-center">Login</h1>
    <form action="#" enctype="multipart/form-data" method="post" name="login" autocomplete="off" class="loginForm">

        <div class="form-group text-left text-white">
            <label for="loginName">Username</label>
            <input class="form-control" type="text" name="loginName" required>
        </div>  

        <div class="form-group text-left text-white">
            <label for="loginPass">Password</label>
            <input class="form-control" type="password" name="loginPass" pattern=".{8,}" required>
        </div>  

        <div class="form-group text-center">
            <input class="btn btn-outline-light col-8 col-lg-6 rounded btnLogin" type="button" name="login" value="Login">
        </div>
    </form>
</div>
<script src="../JS/Login.js"></script>
<?php include ("../Includes/Footer.php");?>

<?php
    setPageTitle("Login", ob_get_contents());
?>