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

    if(isMultiplayer){ //No multiplayer hasn't been properly worked out yet. Too bad!
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "../XHR/Post_Attack.php", true);
        xhr.onload = ()=>{
            if(xhr.readyState === XMLHttpRequest.DONE){
                if(xhr.status === 200){
                    var data = xhr.response;
                    if(data == "success"){
                        console.log(`Did ${JSON.parse(Attack.value)['damage']} damage`);
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
        var attack = JSON.parse(Attack.value);
        var attackDamage = attack['damage'];
        attackDamage = Math.round(attackDamage /= 3);
        var enemy = JSON.parse(Enemy.value);
        var enemyType = enemy['type']
        var attackType = attack['type'];
        if(enemyType['weaknesses'].includes(attackType['name'])){
            attackDamage = Math.round(attackDamage *= 2);
        }
        else if(enemyType['strengths'].includes(attackType['name'])){
            attackDamage = Math.round(attackDamage /= 2);
        }
        else if(enemyType['resistances'].includes(attackType['name'])){
            attackDamage = 0;
        }
        console.log("Attacked enemy " + enemy['name'] + " with " + attack['name'] + " for " + attackDamage + " damage");
        if(EnemyHealthBar.value - attackDamage <= 0){
            spCanAttack = false;
            EnemyHealthBar.value = 0;
            var returnIndex = 10;
            Success.style.display = "block";
            Success.textContent = "You Beat " + enemy['name'] + "! Returning to menu in " + returnIndex + " seconds";
            setInterval(function(){
                returnIndex--;
                if(returnIndex <= 1) Success.textContent = "You Beat " + enemy['name'] + "! Returning to menu in " + returnIndex + " second";
                else Success.textContent = "You Beat " + enemy['name'] + "! Returning to menu in " + returnIndex + " seconds";
            }, 1000);
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

function computerDoAttack(){ //It looks sloppy because it is, why did I ever think this was a good idea
    var enemyPokemon = JSON.parse(Enemy.value);
    var myPokemon = JSON.parse(Me.value);
    var myPokemonType = myPokemon['type'];
    var attacks = enemyPokemon['attacks'];
    var attackIndex = Math.floor(Math.random() * attacks.length);
    var attack = attacks[attackIndex];
    var attackType = attack['type'];
    var damage = attack['damage'];
    damage = Math.round(damage /= 3);
    if(myPokemonType['weaknesses'].includes(attackType['name'])){
        attackDamage = Math.round(damage *= 2);
    }
    else if(myPokemonType['strengths'].includes(attackType['name'])){
        damage = Math.round(damage /= 2);
    }
    else if(myPokemonType['resistances'].includes(attackType['name'])){
        damage = 0;
    }
    console.log("Enemy " + enemyPokemon['name'] + " attacked you with " + attack['name'] + " for " + damage + " damage");
    if(MyHealthBar.value - damage <= 0){
        MyHealthBar.value = 0;
        HealthText.textContent = "Health : 0/"+ JSON.parse(Me.value)['maxHitPoints'];
        var returnIndex = 10;
        Fail.style.display = "block";
        Fail.textContent = "You were defeated by " + enemyPokemon['name'] + ". returning to menu in " + returnIndex + " seconds";
        setInterval(function(){
            returnIndex--;
            if(returnIndex <= 1) Fail.textContent = "You were defeated by " + enemyPokemon['name'] + ". Returning to menu in " + returnIndex + " second";
            else Fail.textContent = "You were defeated by " + enemyPokemon['name'] + ". Returning to menu in " + returnIndex + " seconds";
        }, 1000);
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