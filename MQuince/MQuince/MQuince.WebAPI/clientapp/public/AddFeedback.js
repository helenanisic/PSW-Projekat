
var app = new Vue({
	el: '#addFeedback',
	data: {
		Comment: "",
		UserRole: ""
	},
	methods: {
		submit() {
			if (this.Comment != "") {
				axios
					.post("/api/Feedback", {
						Comment: this.Comment
					}, {
							headers: {
								'Authorization': "Bearer " + localStorage.getItem("access_token")
							}
					}).then(response => {
						JSAlert.alert("Your feedback has been saved!");

						setTimeout(function () {
							if (window.location.hash != '#r') {
								window.location.hash = 'r';
								window.location.reload(1);
							}
						}, 3000);


					})
			} else {
				JSAlert.alert("You have to fill in the form");
			}

		}
	},
	created() {
        axios
			.get('/api/User/GetRole', {
				headers: {
					'Authorization': "Bearer " + localStorage.getItem("access_token")
				}
			})
			.then(response => {
				this.UserRole = response.data
				if (this.UserRole != "Patient") {
					window.location.href = 'login.html';
                }
            })
            .catch(error => {
                console.log(error);
                if (error.response.status == 401) {
					window.location.href = 'login.html';
                }
            })
    }
})