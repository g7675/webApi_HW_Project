document.querySelector("#Nameud").value = JSON.parse(sessionStorage.getItem("currentUser")).name
document.querySelector("#UserNameud").value = JSON.parse(sessionStorage.getItem("currentUser")).userName
document.querySelector("#LastNameud").value = JSON.parse(sessionStorage.getItem("currentUser")).lastName
document.querySelector("#Passwordud").value = JSON.parse(sessionStorage.getItem("currentUser")).password


async function Update() { 
    

    const Nameud = document.querySelector("#Nameud").value
    const UserNameud = document.querySelector("#UserNameud").value
    const LastNameud = document.querySelector("#LastNameud").value
    const Passwordud = document.querySelector("#Passwordud").value
    alert(9999)
    const user = {
        UserName: UserNameud || sessionStorage.getItem("currentUser").UserName,
        Name: Nameud || sessionStorage.getItem("currentUser").Name,
        LastName: LastNameud || sessionStorage.getItem("currentUser").LastName,
        Password: Passwordud || sessionStorage.getItem("currentUser").Password,
        Id: JSON.parse(sessionStorage.getItem("currentUser")).id
    }
        
    try {
        const responsePost = await fetch(`api/user/${JSON.parse(sessionStorage.getItem("currentUser")).id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        sessionStorage.setItem("currentUser",JSON.stringify( user));
        //const responsePostJson = await responsePost.json();
        if (!responsePost.ok) {
            throw new Error(`HTTP error! status: ${responsePost.status}  ${responsePost.text} `);
        }
        alert(`update sucsses! ${JSON.stringify(responsePostJson)}`)
        
    }
    catch (e) {
        alert(e)
    }


}
