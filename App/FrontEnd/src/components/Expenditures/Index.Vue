<template>
  <div class="row-fluid">
    <div class="container">
      <filter-bar></filter-bar>
    </div>
    <div class="container">
      <table class="table">
        <thead>
          <tr>
            <th>{{ $t('expenditure.name') }}</th>
            <th>{{ $t('expenditure.datetime') }}</th>
            <th>{{ $t('expenditure.amount') }}</th>
          </tr>
          <tr v-for="(expenditure, index) in $store.state.expenditures">
            <td>
              <input class="expenditure-input form-element" v-model="expenditure.name" />
            </td>
            <td>
              <input class="expenditure-input form-element" v-model="expenditure.dateTime" />
            </td>
            <td>
              <input class="expenditure-input form-element" v-model="expenditure.amount" />
            </td>
            <td><a><i class="fa fa-pencil" v-on:click="$store.dispatch('saveExpenditure', expenditure)" v-on:leave=""></i></a></td>
            <td><a><i class="fa fa-trash" v-on:click="$store.dispatch('eraseExpenditure', expenditure)"></i></a></td>
          </tr>
          <tr>
            <td v-on:click="$store.dispatch('pushExpenditure', {})">
              <a><i class="fa fa-plus"></i></a>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
        </thead>
      </table>
    </div>
  </div>
</template>

<script>
  import FilterBar from '@/components/Expenditures/FilterBar'

  export default {
    name: 'ExpenditureIndex',
    created: function () {
      this.$store.commit('postExpenditures')
    },
    components: {
      'filter-bar': FilterBar,
    }
  }
</script>
