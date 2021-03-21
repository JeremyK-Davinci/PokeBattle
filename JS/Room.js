const Form = document.querySelector(".gameForm"),
AttackButtons = document.querySelectorAll(".btnAttack"),
Fail = document.querySelector(".responseFail"),
Success = document.querySelector(".responseSuccess"),
Attack = document.querySelector(".attack"),
Enemy = document.querySelector(".enemyPokemon"),
Me = document.querySelector(".myPokemon"),
EnemyHealthBar = document.getElementById("pokemon-health-enemy"),
MyHealthBar = document.getElementById("pokemon-health-me"),
HealthText = document.getElementById("pokemon-health-text");

AttackButtons.forEach(btn =>{
    btn.addEventListener("click", doAttack);
});

var isMultiplayer = false;
var spCanAttack = true;
var MyHealth = JSON.parse(Me.value)['hitPoints'];

function doAttack(){
    Attack.value = this.value

    if(isMultiplayer){
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "../XHR/Post_Attack.php", true);
        xhr.onload = ()=>{
            if(xhr.readyState === XMLHttpRequest.DONE){
                if(xhr.status === 200){
                    var data = xhr.response;
                    if(data == "success"){
                        console.log(`Did ${JSON.parse(Attack.value)['damage']} damage`)
                    }
                    else{
                        if(data != null){
                            Fail.textContent = data;
                            Fail.style.display = "block";
                            setTimeout(function(){
                                Fail.style.display = "none";
                            }, 2000);
                        }
                    }
                }
            }
        }

        var fd = new FormData(Form);
        xhr.send(fd);
    }
    else{
        if(!spCanAttack) return;
        var attackDamage = JSON.parse(Attack.value)['damage'];
        attackDamage = Math.round(attackDamage /= 3);
        console.log("Attacked enemy " + JSON.parse(Enemy.value)['name'] + " with " + JSON.parse(Attack.value)['name'] + " for " + attackDamage + " damage");
        if(EnemyHealthBar.value - attackDamage <= 0){
            spCanAttack = false;
            EnemyHealthBar.value = 0;
            Success.textContent = "You Beat " + JSON.parse(Enemy.value)['name'] + "! returning to menu in 10 seconds";
            Success.style.display = "block";
            setTimeout(function(){
                Success.style.display = "none";
                window.location.href = "../Game/Rooms.php";
            }, 10000);
        }
        else{
            spCanAttack = false;
            EnemyHealthBar.value -= attackDamage;
            computerDoAttack();
        }
    }

    Attack.value = '';
}

function recieveAttack(){
    if(isMultiplayer){
        var xhr = new XMLHttpRequest();
        xhr.open("GET", "../XHR/Get_Attack.php", true);
        xhr.onload = ()=>{
            if(xhr.readyState === XMLHttpRequest.DONE){
                if(xhr.status === 200){
                    var data = xhr.response;
                    if(data.includes("success")){
                        data.replace("success", "");
                        console.log(data);
                    }
                    else return;
                }
            }
        }
        xhr.send();
    }
    else return;
}

function isSinglePlayer(){
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "../XHR/Get_MPStatus.php", true);
    xhr.onload = ()=>{
        if(xhr.readyState === XMLHttpRequest.DONE){
            if(xhr.status === 200){
                var data = xhr.response;
                if(data == "Multiplayer"){
                    isMultiplayer = true;
                }
                else{
                    isMultiplayer = false;
                }
                console.log("isMultiplayer = " + isMultiplayer);
            }
        }
    }
    xhr.send();
}

function updateHitPoints(){
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "../XHR/Get_MPStatus.php", true);
    xhr.onload = ()=>{
        if(xhr.readyState === XMLHttpRequest.DONE){
            if(xhr.status === 200){
                var data = xhr.response;
                if(data == "Multiplayer"){
                    isMultiplayer = true;
                }
                else{
                    isMultiplayer = false;
                }
                console.log("isMultiplayer = " + isMultiplayer);
            }
        }
    }
    xhr.send();
}

function computerDoAttack(){
    var enemyPokemon = JSON.parse(Enemy.value);
    var attacks = enemyPokemon['attacks'];
    var attackIndex = Math.floor(Math.random() * attacks.length);
    var attack = attacks[attackIndex];
    var damage = attack['damage'];
    damage = Math.round(damage /= 3);
    console.log("Enemy " + enemyPokemon['name'] + " attacked you with " + attack['name'] + " for " + damage + " damage");
    if(MyHealthBar.value - damage <= 0){
        MyHealthBar.value = 0;
        HealthText.textContent = "Health : 0/"+ JSON.parse(Me.value)['maxHitPoints'];
        Fail.textContent = "You were defeated by " + enemyPokemon['name'] + ". returning to menu in 10 seconds";
        Fail.style.display = "block";
        setTimeout(function(){
            Fail.style.display = "none";
            window.location.href = "../Game/Rooms.php";
        }, 10000);
    }
    else{
        MyHealthBar.value -= damage;
        MyHealth -= damage;
        HealthText.textContent = "Health: " + MyHealth + "/" + JSON.parse(Me.value)['maxHitPoints'] ;       
        spCanAttack = true;
    }
}

isSinglePlayer();
setInterval(recieveAttack(), 500);