# Stage 1: Build the Angular application
FROM node:21 as build
WORKDIR /app/presentation
COPY ./package.json ./package-lock.json ./
RUN npm install
COPY . .
RUN npm run build

# Stage 2: Serve the application from Nginx
FROM nginx:1.25
COPY --from=build /app/presentation/dist/presentation/browser /usr/share/nginx/html
COPY ./nginx-custom.conf /etc/nginx/conf.d/default.conf
EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"]
