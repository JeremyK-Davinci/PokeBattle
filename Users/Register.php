<?php include ("../Includes/Header2.php");?>
<?php 
    if(isset($_SESSION['signedIn'])){
        header("location:../Index.php");
    }
?>
<div class="errorDisplay fixed-top mt-5 w-100 text-white bg-danger text-center"></div>
<div class="form-container border border-dark rounded col-8 col-md-6 col-lg-2 offset-2 offset-md-3 offset-lg-5">
    <h1 class="text-white text-center">Register</h1>
    <form action="#" enctype="multipart/form-data" method="post" name="register" autocomplete="off" class="registerForm">

        <div class="form-group text-left text-white">
            <label for="registerName">Username</label>
            <input class="form-control" type="text" name="registerName" required>
        </div>

        <div class="form-group text-left text-white">
            <label for="registerMail">E-mail</label>
            <input class="form-control" type="text" name="registerMail" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required>
        </div>

        <div class="form-group text-left text-white">
            <label for="registerPass">Password</label>
            <input class="form-control" type="password" name="registerPass" pattern=".{8,}" required>
        </div> 

        <div class="form-group text-left text-white">
            <label for="registerPassConfirm">Confirm Password</label>
            <input class="form-control" type="password" name="registerPassConfirm" pattern=".{8,}" required>
        </div>
        <div class="form-group text-center">
            <input class="btn btn-outline-light col-8 col-lg-6 rounded btnRegister" type="submit" name="register" value="Register">
        </div>
    </form>
</div>

<script src="../JS/Register.js"></script>
<?php include ("../Includes/Footer.php");?>

<?php
    setPageTitle("Register", ob_get_contents());
?>