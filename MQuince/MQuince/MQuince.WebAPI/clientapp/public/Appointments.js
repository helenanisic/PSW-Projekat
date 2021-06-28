var app = new Vue({
	el: '#appointments',
	data: {
		appointments: []
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
			.get('/api/Appointment/GetAppointmentsForPatient', {
				headers: {
					'Authorization': "Bearer " + localStorage.getItem("access_token")
				}
			})
			.then(response => {
				this.appointments = response.data
			})

	}
})