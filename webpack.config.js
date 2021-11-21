const path = require("path");

const HtmlWebpackPlugin = require("html-webpack-plugin");

module.exports = {
    mode: "development",
    devtool: "eval-source-map",
    entry: "./src/App.fs.js",
    output: {
        path: path.resolve(__dirname, "./dist"),
        filename: "[name].js",
        clean: true,
    },
    plugins: [
        new HtmlWebpackPlugin({
            filename: "index.html",
            template: "./src/index.html",
        }),
    ],
    module: {
        rules: [
            {
                test: /\.(sass|scss|css)$/,
                use: [
                    'style-loader',
                    'css-loader',
                    {
                        loader: 'sass-loader',
                        options: { implementation: require('sass') }
                    }
                ],
            },
            {
                test: /\.(png|jpg|jpeg|gif|svg|woff|woff2|ttf|eot)(\?.*)?$/,
                use: ['file-loader']
            }
        ]
    }
};
