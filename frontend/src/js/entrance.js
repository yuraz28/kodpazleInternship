document.getElementById('entrance').addEventListener('click', function() {
    var name = document.getElementById('login').value;
    var password = document.getElementById('password').value;

    axios.get('http://localhost:5143/api/user/authorization', {
        params: {
            name: name,
            password: password
        },
        headers: {
            'Accept': '*/*'
        }
    })
  .then(function (response) {
        console.log(response.data);
    })
  .catch(function (error) {
        console.error('Error:', error);
    });
});