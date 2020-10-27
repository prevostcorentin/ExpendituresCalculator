import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    expenditures: {}
  },
  mutations: {
    updateExpenditures (state, data = []) {
      Axios.post(`${process.env.PROTOCOL}://${process.env.SERVER_NAME}:${process.env.SERVER_PORT}/spent`, data, {
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(function (response) {
          state.expenditures = response.data
        })
    }
  }
})
