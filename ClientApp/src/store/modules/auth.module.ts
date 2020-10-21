const state = {
    auth: {
        token: undefined as undefined | string,
        username: undefined as undefined | string
    }
}

const getters = {
    getLoggedIn: (state: any) => state.auth.token != undefined,
    getToken: (state: any) => state.auth.token,
    getUsername: (state: any) => state.auth.username
}

const actions = {
    async setToken({ commit }: any, token: string) {
        commit("setToken", token);
    },

    async setLogin({ commit }: any, { token, username }: any) {
        commit("setLogin", { token, username });
    }
}

const mutations = {
    setToken(state: any, token: string) {
        state.auth.token = token;
    },

    setLogin(state: any, { token, username }: any) {
        state.auth.username = username;
        state.auth.token = token;
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}