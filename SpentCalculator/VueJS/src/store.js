import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    expenditures: [],
  },
  mutations: {
    postExpenditures(state, filter) {
      Axios.post(`${process.env.BASE_URL}/spent`, filter, {
        headers: {
          'Content-Type': 'application/json'
        }
      }).then(function (response) {
        state.expenditures = response.data
      })
    },
    putExpenditure (state, expenditure) {
      Axios.put(`${process.env.BASE_URL}/spent`, expenditure, {
        headers: {
          'Content-Type': 'application/json'
        }
      })
    },
    deleteExpenditure(state, expenditure) {
      Axios.delete(`${process.env.BASE_URL}/spent/`, expenditure, {
        headers: {
          'Content-Type': 'application/json'
        }
      })
    }
  },
  actions: {
    filterExpenditures ({ commit }, filter = []) {
      commit('postExpenditures', filter)
    },
    pushExpenditure({ commit, state }, expenditure) {
      state.expenditures.push(expenditure)
    },
    saveExpenditure({ commit }, expenditure) {
      commit('putExpenditure', expenditure)
    },
    eraseExpenditure({ commit }, expenditure) {
      commit('deleteExpenditure', expenditure)
    }
  }
})
