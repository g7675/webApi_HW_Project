async function exchangeSignUp(){
    const signUps = document.querySelectorAll(".signUp")
    const signIns = document.querySelectorAll(".signIn")
    signIns.forEach(s => s.style.display = "none")
    signUps.forEach(s => s.style.display = "block")
}

async function exchangeSignIn(){ 
    const signUps = document.querySelectorAll(".signUp")
    const signIns = document.querySelectorAll(".signIn")
    signIns.forEach(s => s.style.display = "block")
    signUps.forEach(s => s.style.display = "none")

}


exchangeSignIn()

async function signUp() {
    const NameUp = document.querySelector("#NameUp").value
    const UserNameUp = document.querySelector("#UserNameUp").value
    const LastNameUp = document.querySelector("#LastNameUp").value
    const PasswordUp = document.querySelector("#PasswordUp").value

    const user = {
        UserName: UserNameUp,
        Name: NameUp,
        LastName: LastNameUp,
        Password: PasswordUp,
        Id: 0
    }

    try {
        const responsePost = await fetch("api/user", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        const responsePostJson = await responsePost.json();
        if (!responsePost.ok) {
            throw new Error(`HTTP error! status: ${responsePost.status}  ${responsePost.text} `);
        }
        alert(`you are signed succsesfuly ${JSON.stringify(responsePostJson)}`)
    }
    catch (e) {
        alert(e)
    }


}

async function signIn() {
    const UserName = document.querySelector("#UserNameIn").value
    const Password = document.querySelector("#PasswordIn").value

    const loginUser = {
        UserName: UserName,
        Password: Password,
    }

    try {
        const responsePost = await fetch("api/user/Login", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginUser)
        });
        const responsePostJson = await responsePost.json();
        if (!responsePost.ok) {
            throw new Error(`HTTP error! status: ${responsePost.status}  ${responsePost.text} `);
        }
        alert(`you are signed in succsesfuly ${JSON.stringify(responsePostJson)}`)
        sessionStorage.setItem("currentUser",JSON.stringify( responsePostJson));
        console.log(44444444444)
        console.log(responsePostJson)
        window.location.href = "Update.html";
    }
    catch (e) {
        alert(e)
    }


}