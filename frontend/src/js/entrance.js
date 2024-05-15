document.getElementById('entrance').addEventListener('click', function() {
    var name = document.getElementById('login').value;
    var password = document.getElementById('password').value;

    var data = {
        login: name,
        password: password
    };

    var url = 'http://localhost:5200/api/user/authorization';

    fetch(url, {
        method: 'POST',
        mode: 'no-cors', 
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
   .then(function(response) {
        if (!response.ok) {
            throw new Error("HTTP error " + response.status);
        }
        return response.json();
    })
   .then(function(data) {
        console.log(data);
    })
   .catch(function(error) {
        console.error('Error:', error);
    });
});