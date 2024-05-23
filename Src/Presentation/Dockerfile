# Stage 1: Build the Angular application
FROM node:21 as build
WORKDIR /app/presentation
COPY ./package.json ./package-lock.json ./
RUN npm install
# Install Angular CLI globally
RUN npm install -g @angular/cli
COPY . .
# Start the Angular development server
CMD ["ng", "serve", "--host", "0.0.0.0", "--poll", "1"]
EXPOSE 4200
