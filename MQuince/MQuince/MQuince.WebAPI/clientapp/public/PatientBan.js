var app = new Vue({
	el: '#patientBan',
	data: {
		patients: []
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
			.get('/api/Patient/GetMaliciousPatient', {
				headers: {
					'Authorization': "Bearer " + localStorage.getItem("access_token")
				}
			})
			.then(response => {
				this.patients = response.data
			})

	}
})