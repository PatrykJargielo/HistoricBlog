module.exports = {
    entry: './app/main.ts',
    output: {
        filename: 'bundle.js',
        path: './app/'
    },    
    resolve: {
        // Add `.ts` and `.tsx` as a resolvable extension.
        extensions: ['.ts', '.tsx', '.js'] // note if using webpack 1 you'd also need a '' in the array as well
    },
    module: {
      loaders: [
        { test: /\.css$/, loader:'style!css!' },
        { test: /\.html$/, loader: "html" },
        { test: /\.tsx?$/, loader: 'ts-loader' }
      ],
    },
        devtool: 'source-map'
}