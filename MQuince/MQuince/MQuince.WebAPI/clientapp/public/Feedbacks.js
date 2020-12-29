var app = new Vue({
	el: '#feedbacks',
	data: {
		feedbacks: []
	},
	methods: {

	},
	created() {
		axios
			.get('/api/Feedback/GetPublishedFeedbacks')
            .then(response => {
				this.feedbacks = response.data
			})

	}
})