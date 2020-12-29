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
			else (this.status == "Pending") {
				axios
					.get('/api/Feedback/GetNotPublishedFeedbacks')
                    .then(response => {
						this.feedbacks = response.data
					})
			}
			
		},
    },
	created() {
		axios
			.get('/api/Feedback/GetPublishedFeedbacks')
            .then(response => {
				this.feedbacks = response.data
			})

    }
})