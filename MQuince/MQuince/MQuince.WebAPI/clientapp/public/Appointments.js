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
						for (i = 0; i < self.feedbacks.length; i++) {
							if (self.feedbacks[i].id == fdb.id) {
								self.feedbacks.splice(i, 1);
								break;
							}
						}
						JSAlert.alert("Success!");
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