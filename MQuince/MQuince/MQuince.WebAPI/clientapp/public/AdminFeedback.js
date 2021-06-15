var app = new Vue({
	el: '#adminFeedback',
	data: {
		status: "Published",
		feedbacks: []
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
            .get('/api/User/IsUserTypeAdmin')
            .then(response => {
				this.UserTypePatient = response.data
                axios
                    .get('/api/Feedback/GetPublishedFeedbacks')
                    .then(response => {
                        this.feedbacks = response.data
                    })
            })
            .catch(error => {
                console.log(error);
                if (error.response.status == 400) {
                    window.location.href = 'login.html';
                }
            })
		

    }
})