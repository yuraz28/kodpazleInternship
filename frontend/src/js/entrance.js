document.getElementById('entrance').addEventListener('click', function() {
    var login = document.getElementById('login').value;
    var password = document.getElementById('password').value;

    var requestBody = {
        "login": login,
        "password": password
    };

    var url = 'http://localhost:5050/api/user/auth';

    fetch(url, {
        method: 'POST',
        mode: 'no-cors',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(requestBody)
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