var app = new Vue({
	el: '#adminFeedback',
	data: {
		status: "Published",
		feedbacks: [],
		UserRole: ""
	},
	methods: {
		statusChanged() {
			if (this.status == "Published") {
				axios
					.get('/api/Feedback/GetPublishedFeedbacks')
                    .then(response => {
						this.feedbacks = response.data
					})
			}
			else if (this.status == "Pending") {
				axios
					.get('/api/Feedback/GetNotPublishedFeedbacks')
                    .then(response => {
						this.feedbacks = response.data
					})
			}
			
		},
		approve: function (fdb) {
			var self = this
			JSAlert.confirm("Are you sure you want to approve this feedback?").then(function (result) {
				if (!result)
					return;
				axios
					.put("/api/Feedback/Update", {
						Id: fdb.id,
						Comment: fdb.comment,
						Published: true,
						PatientId: fdb.patientId,
						PatientName: fdb.patientName,
						PatientSurname: fdb.PatientSurname
					},
						{
							headers: {
								'Authorization': "Bearer " + localStorage.getItem("access_token")
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
		},
		remove: function (fdb) {
			var self = this
			JSAlert.confirm("Are you sure you want to remoe this feedback?").then(function (result) {
				if (!result)
					return;
				axios
					.put("/api/Feedback/Update", {
						Id: fdb.id,
						Comment: fdb.comment,
						Published: false,
						PatientId: fdb.patientId,
						PatientName: fdb.patientName,
						PatientSurname: fdb.PatientSurname
					}, {
							headers: {
								'Authorization': "Bearer " + localStorage.getItem("access_token")
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
				.get('/api/Feedback/GetPublishedFeedbacks', {
					headers: {
						'Authorization': "Bearer " + localStorage.getItem("access_token")
					}
				})
				.then(response => {
					this.feedbacks = response.data
				})

				.catch(error => {
					console.log(error);
					if (error.response.status == 400) {
						window.location.href = 'login.html';
					}
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