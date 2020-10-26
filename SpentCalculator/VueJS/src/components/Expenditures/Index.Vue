<template>
  <div class="row-fluid">
    <div class="container">
      <search-bar></search-bar>
    </div>
    <div class="container">
      <table class="table">
        <thead>
          <tr>
            <th>{{ $t('expenditure.name') }}</th>
            <th>{{ $t('expenditure.datetime') }}</th>
            <th>{{ $t('expenditure.amount') }}</th>
          </tr>
          <item v-for="expenditure in filteredExpenditures" v-bind:expenditure="expenditure"></item>
        </thead>
      </table>
    </div>
  </div>
</template>

<script>
  import ExpenditureSearchBar from '@/components/Expenditures/SearchBar'
  import ExpenditureItem from '@/components/Expenditures/ExpenditureItem'

  export default {
    name: 'ExpenditureIndex',
    created: function () {
      this.$store.commit('updateExpenditures')
    },
    computed: {
      filteredExpenditures () {
        return this.$store.state.expenditures
      }
    },
    components: {
      'search-bar': ExpenditureSearchBar,
      'item': ExpenditureItem
    }
  }
</script>
