const Form = document.querySelector(".gameForm"),
AttackButtons = document.querySelectorAll(".btnAttack"),
Attack = document.querySelector(".attack");

AttackButtons.forEach(btn =>{
    btn.addEventListener("click", doAttack);
});

function doAttack(){
    Attack.value = this.value

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
                        console.log(data);
                    }
                    else{
                        console.log(null);
                    }
                }
            }
        }
    }

    var fd = new FormData(Form);
    xhr.send(fd);
}

function recieveAttack(){
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "../XHR/Get_Attack.php", true);
    xhr.onload = ()=>{
        if(xhr.readyState === XMLHttpRequest.DONE){
            if(xhr.status === 200){
                var data = xhr.response;
                if(data.includes("PB_Success")){
                    data.replace("PB_Success", "");
                    console.log(data);
                }
                else return;
            }
        }
    }
    xhr.send();
}