var app = new Vue({
	el: '#patientBan',
	data: {
		patients: [],
		UserRole: ""
	},
	methods: {
		ban: function (patient) {
			var self = this
			JSAlert.confirm("Are you sure you want to ban this patient?").then(function (result) {
				if (!result)
					return;
				axios
					.get("/api/Patient/BanPatient",
					 {
						headers: {
							'Authorization': "Bearer " + localStorage.getItem("access_token")
						 },
						 params: {
							 id: patient.id
                         }

						}).then(response => {
							window.location.reload();

						})
			})
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
				if (this.UserRole != "Admin") {
					window.location.href = 'login.html';
				}

				axios
					.get('/api/Patient/GetMaliciousPatient', {
						headers: {
							'Authorization': "Bearer " + localStorage.getItem("access_token")
						}
					})
					.then(response => {
						this.patients = response.data
					})
			})
			.catch(error => {
				console.log(error);
				if (error.response.status == 401) {
					window.location.href = 'login.html';
				}
			})



	}
})