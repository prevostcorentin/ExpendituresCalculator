<template>
  <div id="app">
    <header>
      <span>Expenditures Calculator</span>
    </header>
    <main>
      <navigation-bar></navigation-bar>
      <router-view></router-view>
    </main>
  </div>
</template>
k
<script>
  import NavigationBar from '@/components/NavigationBar'

  export default {
    name: 'app',
    components: {
      NavigationBar
    }
  }
</script>
