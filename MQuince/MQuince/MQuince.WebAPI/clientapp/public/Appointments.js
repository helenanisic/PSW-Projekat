var app = new Vue({
	el: '#appointments',
	data: {
		appointments: [],
		UserRole: ""
	},
	methods: {
		cancel: function (fdb) {
			var self = this
			JSAlert.confirm("Are you sure you want to cancel this appointment").then(function (result) {
				if (!result)
					return;
				axios
					.get("/api/Appointment/Cancel", {
						headers: {
							'Authorization': "Bearer " + localStorage.getItem("access_token")
						},
						params: {
							id: fdb.id
                        }
					})
					.then(response => {
						JSAlert.alert("Success");
					})
					.catch(error => {
						console.log(error)
						JSAlert.alert(error.response.data);

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
				if (this.UserRole != "Patient") {
					window.location.href = 'login.html';
				}

				axios
					.get('/api/Appointment/GetAppointmentsForPatient', {
						headers: {
							'Authorization': "Bearer " + localStorage.getItem("access_token")
						}
					})
					.then(response => {
						this.appointments = response.data
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