document.getElementById('entrance').addEventListener('click', function() {
    var login = document.getElementById('login').value;
    var password = document.getElementById('password').value;

    fetch('http://localhost:5143/api/user/auth', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            login: login,
            password: password
        }),
    })
  .then(response => response.json())
  .then(data => console.log(data))
  .catch((error) => console.error('Error:', error));
});